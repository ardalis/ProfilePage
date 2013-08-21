using System;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Core.Tests
{
    [Binding]
    public class ProfileSteps
    {
        private Profile _profile;

        [Given(@"A user has created a new public profile")]
        public void GivenAUserHasCreatedANewPublicProfile()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"The profile has been created")]
        public void WhenTheProfileHasBeenCreated()
        {
            //ScenarioContext.Current.Pending();
            _profile = new Profile();
        }
        
        [Then(@"The profile should begin with zero points")]
        public void ThenTheProfileShouldBeginWithZeroPoints()
        {
            Assert.AreEqual(0, _profile.Points);
        }

        [Then(@"The profile should have a unique identifier")]
        public void ThenTheProfileShouldHaveAUniqueIdentifier()
        {
            Assert.IsNotNull(_profile.Id);
            Assert.AreNotEqual(Guid.Empty, _profile.Id);
        }

    }
}
