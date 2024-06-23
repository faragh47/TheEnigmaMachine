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
        [InlineData("3ABCDEFGHIJKLMNOPQRSTZ")]
        [InlineData("AAAAAFGHIJKLAAAAAAAATZ")]
        public void Test_Plugboard_Is_Valid_Wire(string wire)
        {
            // Arrange
            Plugboard wrongPlugboard = new Plugboard(wire);

            // Act
            var validity = wrongPlugboard.IsValid();
            var IsExistFalse = !validity.Any(x => x.Item1.Equals(false));
            // Assert
            Assert.Equal(IsExistFalse, false);
        }
    }
}