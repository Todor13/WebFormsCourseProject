using Forum.Data;
using Forum.Presenters;
using Forum.Views;
using Forum.Views.ForumViews.EditViews;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Tests.PresentersTests
{
    [TestFixture]
    public class ThreadPresenterGetThreadTests
    {
        [Test]
        public void ThreadPresenter_GetThread_ShouldGetRightThread()
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

            forumData.Setup(t => t.ThreadsRepository.GetThreadById(It.Is<int>(x=>x == 1))).Returns(thread);
            forumData.Setup(a => a.AnswersRepository.GetAnswersByThreadId(It.IsAny<int>())).Returns(answers.AsQueryable);

            view.Raise(v => v.GetThread += null, view.Object, new GetByIdEventArgs(1));

            Assert.AreEqual(thread, view.Object.Model.Thread); 
        }

        [Test]
        public void ThreadPresenter_GetThread_ShouldGetRightAnswers()
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

            view.Raise(v => v.GetThread += null, view.Object, new GetByIdEventArgs(1));

            Assert.AreEqual(answers, view.Object.Model.Answers);
        }

        [Test]
        public void ThreadPresenter_GetThread_ShouldReturnNullWhenIsNotVisible()
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

            view.Raise(v => v.GetThread += null, view.Object, new GetByIdEventArgs(1));

            Assert.AreEqual(null, view.Object.Model.Thread);
        }

        [Test]
        public void ThreadPresenter_GetThread_ShouldReturnEmptyWhenAnswersAreNotVisible()
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

            view.Raise(v => v.GetThread += null, view.Object, new GetByIdEventArgs(1));

            Assert.IsInstanceOf<IEnumerable>(view.Object.Model.Answers);
            Assert.AreEqual(0, view.Object.Model.Answers.Count());
        }
    }
}
