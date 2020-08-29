using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using SinavOlusturma.Entities;
using SinavOlusturma.Models;
using SinavOlusturma.Repositories;

namespace SinavOlusturma.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamRepository examRepository;
        private readonly IFormQuestionRepository formQuestionRepository;
        private readonly IFormQuestionOptionRepository formQuestionOptionRepository;

        public ExamController(IExamRepository examRepository, IFormQuestionRepository formQuestionRepository, IFormQuestionOptionRepository formQuestionOptionRepository)
        {
            this.examRepository = examRepository;
            this.formQuestionRepository = formQuestionRepository;
            this.formQuestionOptionRepository = formQuestionOptionRepository;
        }

        public IActionResult Index()
        {
            var exams = examRepository.GetAll().Where(p => p.RecordStatus == Entities.RecordStatus.A).ToList();
            return View(exams);
        }

        public IActionResult CreateExam()
        {
            Uri url = new Uri("https://www.wired.com/");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            HtmlNodeCollection titles = document.DocumentNode.SelectNodes("//div[@class='cards-component__row']//li//h2");
            HtmlNodeCollection links = document.DocumentNode.SelectNodes("//div[@class='cards-component__row']//li//a");

            ContentViewModel viewModel = new ContentViewModel();
            List<Exam> contentList = new List<Exam>();

            for (int i = 0; i < 5; i++)
            {
                Exam content = new Exam();

                content.Name = titles[i].InnerText;

                string result = links[i].Attributes["href"].Value;
                url = new Uri("https://www.wired.com" + result);
                WebClient clientSub = new WebClient();
                string htmlSub = clientSub.DownloadString(url);
                HtmlAgilityPack.HtmlDocument documentSub = new HtmlAgilityPack.HtmlDocument();
                documentSub.LoadHtml(htmlSub);
                HtmlNodeCollection articles = documentSub.DocumentNode.SelectNodes("//p");

                for (int j = 5; j < articles.Count - 4; j++)
                {
                    content.Article += articles[j].InnerText;
                }

                contentList.Add(content);
            }

            viewModel.contentList = contentList;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateExam(Exam examModel)
        {
            try
            {
                Exam exam = new Exam()
                {
                    Name = examModel.Name,
                    CreateDate = DateTime.Now,
                    Article = examModel.Article
                };
                examRepository.CreateExam(exam);

                foreach (var que in examModel.questions)
                {
                    FormQuestion question = new FormQuestion();
                    question.ExamId = exam.Id;
                    question.QuestionText = que.QuestionText;
                    formQuestionRepository.CreateQuestion(question);

                    foreach (var opt in que.options)
                    {
                        FormQuestionOption option = new FormQuestionOption();
                        option.FormQuestionId = question.Id;
                        option.OptionText = opt.OptionText;
                        option.IsAnswer = opt.IsAnswer;
                        formQuestionOptionRepository.CreateOption(option);
                    }
                }

                return RedirectToAction("Index", "Exam");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Delete(int id)
        {
            var exam = examRepository.Find(id);
            return View(exam);
        }

        public IActionResult DeleteConfirmedAsync(int id)
        {
            examRepository.DeleteExam(id);

            return RedirectToAction("Index");
        }

        public IActionResult EnterExam(int id)
        {
            var exam = examRepository.Find(id);

            var questions = formQuestionRepository.GetAll(p => p.ExamId == exam.Id).ToList();

            int count = 0;
            foreach (var que in questions)
            {
                var opts = formQuestionOptionRepository.GetAll(p => p.FormQuestionId == que.Id).ToList();
                questions[count].options = opts;
                count++;
            }

            exam.questions = questions;

            return View(exam);
        }

        [HttpPost]
        public IActionResult EnterExam(FormAnswer things)
        {
            return View();
        }
    }
}