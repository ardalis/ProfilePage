using System;
using Core.Interfaces;
using Core.Model;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Telerik.JustMock;

namespace Core.Tests.Services
{
    [Binding]
    public class ActivityServiceSteps
    {
        private ActLoggerService _activityService;
        private Act _act;
        private IActRepository _mockActivityRepository;
        private Act _actRaisedInEvent;

        [Given(@"I have an instance of ActivityService")]
        public void GivenIHaveAnInstanceOfActivityService()
        {
            _mockActivityRepository = Mock.Create<IActRepository>(Behavior.Strict);
            Mock.Arrange(() => _mockActivityRepository.Save(Arg.IsAny<Act>()));
            _activityService = new ActLoggerService(_mockActivityRepository);
            _activityService.Logged += delegate(object sender, ActLoggedEventArgs e)
            {
                _actRaisedInEvent = e.Act;
            };
        }
        
        [Given(@"I have an instance of an Act")]
        public void GivenIHaveAnInstanceOfAnAct()
        {
            _act = new Act(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, "test act");
        }
        
        [When(@"I log the activity")]
        public void WhenILogTheActivity()
        {
            _activityService.LogAct(_act);
        }
        
        [Then(@"the activity should be persisted")]
        public void ThenTheActivityShouldBePersisted()
        {
            Mock.Assert(_mockActivityRepository);
        }
        
        [Then(@"an ActLogged event should be fired")]
        public void ThenAnActLoggedEventShouldBeFired()
        {
            Assert.IsNotNull(_actRaisedInEvent);
            Assert.AreEqual(_act, _actRaisedInEvent);
        }
    }
}
