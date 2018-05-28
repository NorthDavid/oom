using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task4;

namespace Task4
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void SimpleTest()
        {
            Assert.IsTrue(1 == 2);
        }

        [Test]
        public void CanCreateMusicTitle()
        {
            var x = new MusicTitle("Interpret666","Title333",1010,new Length(1234,"s"),999);

            Assert.IsTrue(x.Interpret == "Interpret666");
            Assert.IsTrue(x.Title == "Title333");
            Assert.IsTrue(x.Year == 1010);
            Assert.IsTrue(x.Duration.Duration == 1234);
            Assert.IsTrue(x.Duration.Unit == "s");
            Assert.IsTrue(x.Price == 999);
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyInterpret1()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle(null, "Title333", 1010, new Length(1234, "s"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyInterpret2()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("", "Title333", 1010, new Length(1234, "s"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyTitle1()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", null, 1010, new Length(1234, "s"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyTitle2()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "", 1010, new Length(1234, "s"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithNegativeYear()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", -1010, new Length(1234, "s"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyLength()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", 1010, null, 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithNegativeLengthDuration()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", 1010, new Length(-1234, "s"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyLengthUnit1()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", 1010, new Length(1234, ""), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithEmptyLengthUnit2()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", 1010, new Length(1234, null), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithWrongLengthUnit()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", 1010, new Length(1234, "e"), 999);
            });
        }
        [Test]
        public void CannotCreateMusicTitleWithNegativePrize()
        {
            Assert.Catch(() =>
            {
                var x = new MusicTitle("Interpret666", "Title333", 1010, new Length(1234, "s"), -999);
            });
        }
    }
}
