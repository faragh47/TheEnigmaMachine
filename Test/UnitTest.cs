using TheEnigmaMachine;

namespace Test
{
    public class UnitTest
    {

        [Theory]
        [InlineData('A', "B", "ABCDEFGHIJKLMNOPQRSTZ")]
        [InlineData('B', "A", "ABCDEFGHIJKLMNOPQRSTZ")]
        [InlineData('X', "X", "ABCDEFGHIJKLMNOPQRSTZ")]
        [InlineData('.', ".", "ABCDEFGHIJKLMNOPQRSTZ")]
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
        [InlineData(false, "3ABCDEFGHIJKLMNOPQRSTZ")]
        public void Test_Plugboard_Is_Valid_Wire(bool isValid, string wire)
        {
            // Arrange
            Plugboard wrongPlugboard = new Plugboard("3ABCDEFGHIJKLMNOPQRSTZ");

            // Act
            var validity = wrongPlugboard.IsValid();

            // Assert
            Assert.Equal(validity.Item1, isValid);
        }
    }
}