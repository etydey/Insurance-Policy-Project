using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using InsurancePolicyApplication.Controllers;
using InsurancePolicyApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace XUnitTestProject
{
    public class ContentInsuranceUnitTest
    {
        public class Index
        {
            [Fact]
            public void ContentInsurancesController_Index_Test()
            {
                //Arrange
                var policyService = new Mock<IInsurancePolicyService>();
                policyService.Setup(c => c.GetContentInsurances())
                .Returns(new List<ContentInsurance>());
                policyService.Setup(c => c.GetCategories())
                .Returns(new List<Category>());
                ContentInsurancesController controller = new ContentInsurancesController(policyService.Object);
            
                //Act
                ViewResult result = controller.Index() as ViewResult;

                //Assert
                result.As<ViewResult>().Model.Should().BeOfType<CommonViewModel>();
                Assert.NotNull(result.Model);
             }

            [Fact]
            public void Delete_ValidId_RedirectToIndexView()
            {
                //Arrange
                int contentId = 1;
                var policyService = new Mock<IInsurancePolicyService>();
                policyService.Setup(c => c.DeleteContent(contentId));
                ContentInsurancesController controller = new ContentInsurancesController(policyService.Object);

                //Act
                IActionResult result = controller.Delete(contentId) as ActionResult;
               
                //Assert
                result
                    .Should()
                    .BeOfType<RedirectToActionResult>();
            }

            [Fact]
            public void Add_NewContent_RedirectToIndexView()
            {
                //Arrange
                var viewModel = new CommonViewModel();
                viewModel.addContent = new ContentInsurance { Name = "Test Content", Value = 1000, CategoryId = 2 };
                var policyService = new Mock<IInsurancePolicyService>();
                policyService.Setup(c => c.AddContent(viewModel.addContent));

                ContentInsurancesController controller = new ContentInsurancesController(policyService.Object);

                //Act
                IActionResult result = controller.Create(viewModel) as ActionResult;

                //Assert
                result
                    .Should()
                    .BeOfType<RedirectToActionResult>();
            }
        }
    }
}
