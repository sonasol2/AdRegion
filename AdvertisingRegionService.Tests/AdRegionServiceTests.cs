// using AdvertisingRegionService.API.Services;
// using NUnit.Framework;
//
// namespace AdvertisingRegionService.Tests;
//
// [TestFixture]
// public class AdRegionServiceTests
// {
//     private AdRegionService _service;
//     
//     [SetUp]
//     public void Setup()
//     {
//         _service = new AdRegionService();
//     }
//
//     [Test]
//     public void UploadFileCorrectlyTest()
//     {
//         string fileContent = "Яндекс.Директ:/ru\nГазета уральских москвичей:/ru/msk,/ru/permobl";
//
//         var result = _service.UploadFile(fileContent);
//         Assert.That(result.IsSuccessfully, Is.True);
//         
//         
//         var searchResult = _service.GetPlatformByLocation("/ru/msk");
//         Assert.That(searchResult.Result, Does.Contain("Газета уральских москвичей"));
//         Assert.That(searchResult.Result, Does.Contain("Яндекс.Директ"));
//     }
//     
//     [Test]
//     public void GetPlatformByLocation_ReturnCorrect()
//     {
//         string fileContent = "Крутая реклама:/ru/svrd\nЯндекс.Директ:/ru";
//         _service.UploadFile(fileContent);
//
//         var result = _service.GetPlatformByLocation("/ru/svrd");
//
//         Assert.That(result.IsSuccessfully, Is.True);
//         Assert.That(result.Result, Does.Contain("Крутая реклама"));
//         Assert.That(result.Result, Does.Contain("Яндекс.Директ"));
//     }
//     
//     [Test]
//     public void GetPlatformByLocation_ReturnError()
//     {
//         string fileContent = "Крутая реклама:/ru/svrd\nЯндекс.Директ:/ru";
//         _service.UploadFile(fileContent);
//         
//         var result = _service.GetPlatformByLocation("/ru/svrd");
//         
//         Assert.That(result.IsSuccessfully, Is.True);
//
//         Assert.That(result.Result, Does.Contain("Крутая реклама"));
//         Assert.That(result.Result, Does.Contain("Яндекс.Директ"));
//     }
// }