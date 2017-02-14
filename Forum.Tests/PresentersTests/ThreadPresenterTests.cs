using Forum.Data;
using Forum.Data.Repositories;
using Forum.Presenters;
using Forum.Views;
using Forum.Views.Events;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Forum.Tests.PresentersTests
{   
    [TestFixture]
    public class ThreadPresenterTests
    {
        [Test]
        public void ThreadPresenter_ShouldGetRightThread()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var thread = new Thread() { Id = 1, IsVisible = true };
            var answer1 = new Answer() { Id = 1, IsVisible = true };
            var answer2 = new Answer() { Id = 2, IsVisible = true };
            var comment = new Comment() { Id = 1, IsVisible = true };
            answer1.Comments.Add(comment);
            thread.Answers.Add(answer1);
            thread.Answers.Add(answer2);

            var answers = new List<Answer>()
            {
                answer1,
                answer2
            };

            forumData.Setup(t => t.ThreadsRepository.GetThreadById(It.IsAny<int>())).Returns(thread);
            forumData.Setup(a => a.AnswersRepository.GetAnswersByThreadId(It.IsAny<int>())).Returns(answers.AsQueryable);

            view.Raise(v => v.GetThread += null, view.Object, new GetThreadEventArgs(1));

            Assert.AreEqual(thread, view.Object.Model.Thread); 
        }

        [Test]
        public void ThreadPresenter_ShouldGetRightAnswers()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var thread = new Thread() { Id = 1, IsVisible = true };
            var answer1 = new Answer() { Id = 1, IsVisible = true };
            var answer2 = new Answer() { Id = 2, IsVisible = true };
            var comment = new Comment() { Id = 1, IsVisible = true };
            answer1.Comments.Add(comment);
            thread.Answers.Add(answer1);
            thread.Answers.Add(answer2);

            var answers = new List<Answer>()
            {
                answer1,
                answer2
            };

            forumData.Setup(t => t.ThreadsRepository.GetThreadById(It.IsAny<int>())).Returns(thread);
            forumData.Setup(a => a.AnswersRepository.GetAnswersByThreadId(It.IsAny<int>())).Returns(answers.AsQueryable);

            view.Raise(v => v.GetThread += null, view.Object, new GetThreadEventArgs(1));

            Assert.AreEqual(answers, view.Object.Model.Answers);
        }

        [Test]
        public void ThreadPresenter_ShouldReturnNullWhenIsNotVisible()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var thread = new Thread() { Id = 1, IsVisible = false };
            var answer1 = new Answer() { Id = 1, IsVisible = true };
            var answer2 = new Answer() { Id = 2, IsVisible = true };
            var comment = new Comment() { Id = 1, IsVisible = true };
            answer1.Comments.Add(comment);
            thread.Answers.Add(answer1);
            thread.Answers.Add(answer2);

            var answers = new List<Answer>()
            {
                answer1,
                answer2
            };

            forumData.Setup(t => t.ThreadsRepository.GetThreadById(It.IsAny<int>())).Returns(thread);
            forumData.Setup(a => a.AnswersRepository.GetAnswersByThreadId(It.IsAny<int>())).Returns(answers.AsQueryable);

            view.Raise(v => v.GetThread += null, view.Object, new GetThreadEventArgs(1));

            Assert.AreEqual(null, view.Object.Model.Thread);
        }

        [Test]
        public void ThreadPresenter_ShouldReturnEmptyWhenAnswersAreNotVisible()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var thread = new Thread() { Id = 1, IsVisible = true };
            var answer1 = new Answer() { Id = 1, IsVisible = false };
            var answer2 = new Answer() { Id = 2, IsVisible = false };
            var comment = new Comment() { Id = 1, IsVisible = true };
            answer1.Comments.Add(comment);
            thread.Answers.Add(answer1);
            thread.Answers.Add(answer2);

            var answers = new List<Answer>()
            {
                answer1,
                answer2
            };

            forumData.Setup(t => t.ThreadsRepository.GetThreadById(It.IsAny<int>())).Returns(thread);
            forumData.Setup(a => a.AnswersRepository.GetAnswersByThreadId(It.IsAny<int>())).Returns(answers.AsQueryable);

            view.Raise(v => v.GetThread += null, view.Object, new GetThreadEventArgs(1));

            Assert.AreEqual(new List<Answer>(), view.Object.Model.Answers);
        }

        [TestCase("test")]
        [TestCase("AbSbxbBSD123 44")]
        public void ThreadPresenter_ShouldCreateAnswerCorrectly(string testContent)
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var httpContext = new Mock<HttpContextBase>();
            var forumData = new Mock<IForumData>();
            var identity = new Mock<IIdentity>();
            var user = new Mock<IPrincipal>();
            var answersRepository = new Mock<IAnswersRepository>();

            httpContext.Setup(h => h.User).Returns(user.Object);
            user.Setup(u => u.Identity).Returns(identity.Object);
            forumData.Setup(d => d.AnswersRepository).Returns(answersRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object)
            {
                HttpContext = httpContext.Object
            };

            view.Raise(v => v.Answer += null, view.Object, new AnswerThreadEventArgs(testContent, 1));

            answersRepository.Verify(r => r.CreateAnswer(It.Is<Answer>(a => a.Contents == testContent)));
        }

        [TestCase("Test")]
        [TestCase("ZxYhj 13 01 xasJg")]
        public void ThreadPresenter_ShouldCreateCommentsCorrectly(string testContent)
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var httpContext = new Mock<HttpContextBase>();
            var forumData = new Mock<IForumData>();
            var identity = new Mock<IIdentity>();
            var user = new Mock<IPrincipal>();
            var commentsRepository = new Mock<ICommentsRepository>();

            httpContext.Setup(h => h.User).Returns(user.Object);
            user.Setup(u => u.Identity).Returns(identity.Object);
            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object)
            {
                HttpContext = httpContext.Object
            };

            view.Raise(v => v.Comment += null, view.Object, new CommentAnswerEventArgs(1, testContent));

            commentsRepository.Verify(r => r.CreateComment(It.Is<Comment>(c => c.Contents == testContent)));
        }
    }
}
