using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        public IEnumerable<Categories> AllCategorys
        {
            get
            {
                return new List<Categories>
                {
                    new Categories()
                    {
                        Id = 1,
                        Name = "Микроволновые печи",
                        Description = "Электроприбор для быстрого подогрева, приготовления и размораживания пищи. Главное преимущество микроволновой печи перед духовкой – нагрев не только с поверхности, но и по объему."
                    },
                    new Categories()
                    {
                        Id = 2,
                        Name = "Мультиварки",
                        Description = "Многофункциональное устройство с функциями жарки, варки, тушения, томления, готовки на пару, приготовления десертов и пр. Мультиварка легко заменит собой множество устройств, используемых для приготовления пищи. Прибор отличается простым управлением и позволяет готовить даже людям с нулевым кулинарным опытом – необходимо лишь измельчить ингредиенты из рецепта и включить программу."
                    }
                };
            }
        }
    }
}
