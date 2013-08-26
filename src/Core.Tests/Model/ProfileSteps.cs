using System;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Core.Tests.Model
{
    [Binding]
    public class ProfileSteps
    {
        private Profile _profile;
        private Profile _profileRaisedInNewLevelAchievedEvent;

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

        [Given(@"A profile exists with (.*) points")]
        public void GivenAProfileExistsWithPoints(int p0)
        {
            _profile = new Profile() { Points = p0 };
        }

        [When(@"The profile has (.*) points applied")]
        public void WhenTheProfileHasPointsApplied(int p0)
        {
            _profile.NewLevelAchieved += (o, e) =>
            {
                _profileRaisedInNewLevelAchievedEvent = e.Profile;
            };
            _profile.ApplyPoints(p0, new Core.Services.ProfileLevelService());
        }

        [Then(@"The profile should trigger a NewLevelAchieved Event")]
        public void ThenTheProfileShouldTriggerANewLevelAchievedEvent()
        {
            Assert.IsNotNull(_profileRaisedInNewLevelAchievedEvent);
        }


    }
}
