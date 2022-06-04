using blog.Infrastructure.Models;
using blog.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.tests.Mocks
{
    internal class CategoryMock
    {
        public static CategoryDto ObjectDTO()
        {
            return new CategoryDto(
                name: "crime",
                type: "notice"
            );
        }
        public static Category ObjectClass( CategoryDto category )
        {
            return new Category(
               category.Name,
               category.Type
            );
        }

        public static CategoryDto NewCategoryToEdit()
        {
            return new CategoryDto(
                name: "gossip",
                type: "celebrities"
            );
        }

        public static List<Category> ListCategories()
        {
            return new List<Category>() {
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
                ObjectClass(ObjectDTO()),
            };
        }
    }
}
