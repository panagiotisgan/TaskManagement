using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastracture.Test
{
    public class AssignmentServiceTests
    {
        [Fact]
        public void Success_Test()
        {
            int number = 8;

            Assert.False(false);
            Assert.True(true);
            Assert.Equal(8, number);
        }

        [Fact]
        public void Success_Test_Second()
        {
            int number = 18;

            Assert.False(false);
            Assert.True(true);
            Assert.Equal(18, number);
        }
    }
}
