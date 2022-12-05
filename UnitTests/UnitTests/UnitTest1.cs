using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TvSet;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        TvSet.TvSet tv;

        [TestMethod]                        //Тесты с методом TurnOff(); 
        public void TurOff_The_Switched_Off_Tv()
        {
            tv = new TvSet.TvSet();
            bool isOn = false;
            bool result = tv.TurnOff();

            Assert.AreEqual(isOn, result);
        }
        [TestMethod]
        public void TurnOff_The_Switched_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            bool isOn = false;
            bool result = tv.TurnOff();

            Assert.AreEqual(isOn, result);
        }

        [TestMethod]                        //Тесты с методом TurnOn();
        public void TurnOn_The_Switched_Off_Tv()
        {
            tv = new TvSet.TvSet();
            bool isOn = true;
            bool result = tv.TurnOn();

            Assert.AreEqual(isOn, result);
        }
        [TestMethod]
        public void TurnOn_The_Switched_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            bool isOn = true;
            bool result = tv.TurnOn();

            Assert.AreEqual(isOn, result);
        }

        [DataRow(1)]                        //Тесты с методом SelectChannel();
        [DataRow(5)]
        [DataRow(99)]
        [DataTestMethod]
        public void ChannelSelection_With_Tv_Off(int Channel) //Параметризировать тест 
        {
            tv = new TvSet.TvSet();

            tv.TurnOn();
            tv.SelectChannel(Channel);
            int result = tv.GetChannel();

            Assert.AreEqual(result, Channel);
        }
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(99)]
        [DataTestMethod]
        public void ChannelSelection_With_Tv_On(int Channel)
        {
            tv = new TvSet.TvSet();

            tv.TurnOn();
            tv.SelectChannel(Channel);
            int result = tv.GetChannel();

            Assert.AreEqual(result, Channel);
        }
        [DataRow(0)]
        [DataRow(100)]
        [DataRow(1000)]
        [DataTestMethod]
        public void Selecting_The_Incorrect_Channell_With_Tv_On(int Channel)
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            bool CanChoose = false;
            bool result = tv.SelectChannel(Channel);

            Assert.AreEqual(CanChoose, result);
        }

        [DataRow(1)]                            //Тесты с методом GetChannel();
        [DataRow(5)]
        [DataRow(99)]
        public void Get_Channel_With_Turn_Off_Tv(int Channel)//Параметризирвоать
        {
            tv = new TvSet.TvSet();
            tv.SelectChannel(Channel);
            int result = tv.GetChannel();
            int CorrectChannel = 0;

            Assert.AreEqual(CorrectChannel, result);
        }
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(99)]
        [DataTestMethod]
        public void Get_Channel_With_Turn_On_Tv(int Channel)
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectChannel(Channel);
            int result = tv.GetChannel();

            Assert.AreEqual(Channel, result);
        }
        [TestMethod]
        public void GetDefaultStateOfTVThenTVIsTurnedOn_ChannelIsFirst()
        {
            tv = new TvSet.TvSet();
            int FirstChannel = 1;

            tv.TurnOn();
            int result = tv.GetChannel();

            Assert.AreEqual(result, FirstChannel);
        }

        [TestMethod]                        //Тесты с методом SelectPreviousChannel();
        public void Select_Previous_Channel_With_Turn_Off_Tv()
        {
            tv = new TvSet.TvSet();
            tv.SelectChannel(5);
            tv.SelectChannel(10);
            tv.SelectPreviousChannel();
            int prevChannel = 0;
            int result = tv.GetChannel();

            Assert.AreEqual(prevChannel, result);
        }
        [TestMethod]                        
        public void Selecting_The_Previous_Channel_When_Switching_Channels_With_Turn_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectChannel(5);
            tv.SelectChannel(10);
            tv.SelectPreviousChannel();
            int prevChannel = 5;
            int result = tv.GetChannel();

            Assert.AreEqual(prevChannel, result);
        }
        [TestMethod]
        public void Select_Previous_Channel_With_Turn_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectPreviousChannel();
            int prevChannel = 1;
            int result = tv.GetChannel();

            Assert.AreEqual(prevChannel, result);
        }

        [TestMethod]                        //Тесты с методом SelectChannelAfter();
        public void Select_Channel_After_With_Turn_Off_Tv()
        {
            tv = new TvSet.TvSet();
            tv.SelectChannelAfter();
            int channelAfter = 0;
            int result = tv.GetChannel();

            Assert.AreEqual(channelAfter, result);
        }
        [TestMethod]                        
        public void Select_Channel_After_With_Turn_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectChannelAfter();
            int channelAfter = 2;
            int result = tv.GetChannel();

            Assert.AreEqual(channelAfter, result);
        }
        [TestMethod]
        public void Choice_Of_Limit_Value_Select_Channel_After_With_Turn_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectChannel(99);
            tv.SelectChannelAfter();
            int channelAfter = 1;
            int result = tv.GetChannel();

            Assert.AreEqual(channelAfter, result);
        }

        [TestMethod]                        //Тесты с методом SelectChannelBefore();
        public void Select_Channel_Before_With_Turn_Off_Tv()
        {
            tv = new TvSet.TvSet();
            tv.SelectChannelBefore();
            int channelBefore = 0;
            int result = tv.GetChannel();

            Assert.AreEqual(channelBefore, result);
        }
        [TestMethod]
        public void Select_Channel_Before_With_Turn_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectChannel(5);
            tv.SelectChannelBefore();
            int channelBefore = 4;
            int result = tv.GetChannel();

            Assert.AreEqual(channelBefore, result);
        }
        [TestMethod]
        public void Choice_Of_Limit_Value_Select_Channel_Before_With_Turn_On_Tv()
        {
            tv = new TvSet.TvSet();
            tv.TurnOn();
            tv.SelectChannel(1);
            tv.SelectChannelBefore();
            int channelBefore = 99;
            int result = tv.GetChannel();

            Assert.AreEqual(channelBefore, result);
        }
    }
}