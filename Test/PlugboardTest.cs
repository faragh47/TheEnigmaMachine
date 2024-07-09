using System.Drawing;
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

        [Fact]
        public void Test_Rotor_Process_Shoud_Correct()
        {
            Rotor rotor = new Rotor("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Q", 'Z', 'O');
            TestRotor(rotor, 'A', 'H', true);
            TestRotor(rotor, 'B', 'B', false);
            TestRotor(rotor, 'C', 'I', false);
            TestRotor(rotor, '.', '.', false);
            TestRotor(rotor, 'D', 'I', false);
            TestRotor(rotor, 'E', 'I', false);
            TestRotor(rotor, 'F', 'J', false);
        }
        private void TestRotor(Rotor rotor, char input, char expectedOutput, bool expectedNotch)
        {
            var result = rotor.Process(input, true);
            Assert.Equal(expectedOutput, result.Item1);
            Assert.Equal(expectedNotch, result.Item2);
        }
    }
}