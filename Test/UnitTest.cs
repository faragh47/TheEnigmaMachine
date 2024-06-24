using TheEnigmaMachine;

namespace Test
{
    public class UnitTest
    {

        [Theory]
        [InlineData('A', "B", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('B', "A", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('X', "X", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('.', ".", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('H', "G", "ABCDEFGHIJKLMNOPQRST")]
        [InlineData('G', "H", "ABCDEFGHIJKLMNOPQRST")]
        public void Test_Plugboard_Process_Shoud_Correct(char input, string output, string wire)
        {
            // Arrange
            Plugboard plugboard = new Plugboard(wire);
            CharKeyboard keyboadA = new CharKeyboard(input);

            // Act
            var outputA = plugboard.Process(keyboadA).Output;

            // Assert
            Assert.Equal(output, outputA.ToString());
        }

        [Theory]
        [InlineData("3ABCDEFGHIJKLMNOPQRSTZ")]
        [InlineData("AAAAAFGHIJKLAAAAAAAATZ")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTZ")]
        public void Test_Plugboard_Has_InValid_Wire(string wire)
        {
            // Arrange
            Plugboard wrongPlugboard = new Plugboard(wire);

            // Act
            var isValid = wrongPlugboard.IsValid();
            // Assert
            Assert.Equal(isValid, false);
        }
    }
}