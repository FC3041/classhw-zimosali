using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E3;







//5555
// [TestClass]
// public class Q3_IDisposablePattern
// {
//     [TestMethod]
//     public void ResourceManager_ShouldDisposeResources()
//     {
//         // Arrange
//         var manager = new ResourceManager();

//         // Act
//         manager.Dispose();

//         // Assert
//         try
//         {
//             manager.UseResource();
//             Assert.Fail("Expected ObjectDisposedException");
//         }
//         catch (ObjectDisposedException)
//         {
//             Assert.IsTrue(true); // تست موفق بود
//         }
//     }
// }