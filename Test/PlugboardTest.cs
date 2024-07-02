using TheEnigmaMachine.Entities;

namespace Test
{
    public class PlugboardTest
    {

        [Theory]
        [InlineData('A', "B", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('B', "A", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('X', "X", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('.', ".", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('H', "G", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('G', "H", "ABCDEFGHIJKLMNOPQRST")]
        public void Test_Plugboard_Process_Shoud_Correct(char input, string output, string instruction)
        {
            // Arrange
            Plugboard plugboard = new Plugboard(instruction);
            // Act
            var outputA = plugboard.Process(input);
            // Assert
            Assert.Equal(output, outputA.ToString());
        }

        [Theory]
        [InlineData("3ABCDEFGHIJKLMNOPQRSTZ")]
        [InlineData("AAAAAFGHIJKLAAAAAAAATZ")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTZ")]
        public void Test_Plugboard_Has_InValid_Wire(string instruction)
        {
            // Arrange
            PlugboardConfiguration wrongPlugboard = new PlugboardConfiguration();
            // Act
            wrongPlugboard.config(instruction);
            // Assert
            Assert.Equal(wrongPlugboard.IsValidInstruction, false);
        }
    }
}