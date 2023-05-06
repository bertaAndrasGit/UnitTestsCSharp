using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCourse.test
{
    public static class WorldsDumbestFunctionTest
    {
        //Naming Convention -ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_Returnsstring() {

            try {
                //Arrange - Go get your variables,whatever you need,your classes, go get functions
                int num = 0;
                WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();

                //Act - Execute this function
                string result = worldsDumbest.ReturnsPikachuIfZero(num);

                //Assert - whatever ever is returned is it what you want?
                if (result == "Pikachu") {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                }
                else {
                    Console.WriteLine("FAILED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                        }




            }
            catch (Exception e) { 
                Console.WriteLine(e);
            }

        }
    }
}
