using Moq;
using NUnit.Framework;
using PhoenixInteractive.Common;
using PhoenixInteractive.Xpression.DesktopClient;
using PhoenixInteractive.Xpression.DesktopClient.MessageDispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixInteractive.Xpression.DesktopClient.Tests
{
   [TestFixture()]
   public class XpressionContainerTests
   {
      /// <summary>
      /// Mock object for ILogWrapper.
      /// </summary>
      private Mock<ILogWrapper> logger = null;

      /// <summary>
      ///  Variable to store error message.
      /// </summary>
      private string errorMsg = null;

      [SetUp]
      public void Initialize()
      {
         this.logger = new Mock<ILogWrapper>();
         this.logger.Setup(m => m.LogLine(It.IsAny<string>(), It.IsAny<Logger.Severity>())).Callback((string msg, Logger.Severity severity) => { this.errorMsg = msg; });
      }

      [Test()]
      [TestCase(@"{""name"":""Ram""}",@"{""name"":""Ram""}")]
      [TestCase("Error", "Error")]
      [TestCase(5,"5")]     
      public void HandleMessageTest(dynamic actual_data,string expected_data )
      {
         MessageConstant messageType = MessageConstant.LOG_ERROR;
         MessageInfo messageInfo = new MessageInfo() { Data = actual_data };

         XpressionContainer xpressionContainer = new XpressionContainer(this.logger.Object);
         xpressionContainer.HandleMessage(messageType, messageInfo);

         this.logger.Verify(m => m.LogLine(It.IsAny<string>(), It.IsAny<Logger.Severity>()), Times.Once());
         Assert.AreEqual(this.errorMsg, expected_data);
      }
   }
}