using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShop.Controllers;
using BethanysPieShop.Tests.Mocks;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Tests.Controllers;

public class PieControllerTests {

    [Fact]
    public void List_EmptyCategory_ReturnsAllPies() {

        var mockPieRepository = RepositoryMocks.GetPieRepository();
        var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

        var result = pieController.List("");

        var viewResult = Assert.IsType<ViewResult>(result);
        var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);

        Assert.Equal(10, pieListViewModel.Pies.Count());
    }
}
