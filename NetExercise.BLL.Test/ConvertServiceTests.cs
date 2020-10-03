using NetExercise.BLL.Services;
using NUnit.Framework;

namespace NetExercise.BLL.Test
{
    [TestFixture]
    internal class ConvertServiceTests
    {
        private ConvertService _target;

        [SetUp]
        public void SetUp()
        {
            _target = new ConvertService();
        }

        [Test]
        public void ConvertToXml_ForEmptyString_ShouldReturnHeader()
        {
            // Arrange
            var input = string.Empty;
            var output = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text />";

            // Act
            var result = _target.ConvertToXml(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToXml_ForWhiteSpacesString_ShouldReturnHeader()
        {
            // Arrange
            var input = "   ";
            var output = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text />";

            // Act
            var result = _target.ConvertToXml(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToXml_ForSingleWord_ShouldReturnCorrectXML()
        {
            // Arrange
            var input = "Mary";
            var output = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text>
  <sentence>
    <word>Mary</word>
  </sentence>
</text>";

            // Act
            var result = _target.ConvertToXml(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToXml_ForSingleSentence_ShouldReturnCorrectXML()
        {
            // Arrange
            var input = "Peter called for the wolf, and Aesop came.";
            var output = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text>
  <sentence>
    <word>Aesop</word>
    <word>and</word>
    <word>called</word>
    <word>came</word>
    <word>for</word>
    <word>Peter</word>
    <word>the</word>
    <word>wolf</word>
  </sentence>
</text>";

            // Act
            var result = _target.ConvertToXml(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToXml_ForMultipleSentences_ShouldReturnCorrectXML()
        {
            // Arrange
            var input = "Mary had a little lamb. Cinderella likes shoes.";
            var output = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text>
  <sentence>
    <word>a</word>
    <word>had</word>
    <word>lamb</word>
    <word>little</word>
    <word>Mary</word>
  </sentence>
  <sentence>
    <word>Cinderella</word>
    <word>likes</word>
    <word>shoes</word>
  </sentence>
</text>";

            // Act
            var result = _target.ConvertToXml(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToXml_ForMultipleSentencesAndWhiteSpaces_ShouldReturnCorrectXML()
        {
            // Arrange
            var input = @"   Mary had ,  a 
little 


lamb. 
   Cinderella    likes shoes.   ";
            var output = @"<?xml version=""1.0"" encoding=""utf-16""?>
<text>
  <sentence>
    <word>a</word>
    <word>had</word>
    <word>lamb</word>
    <word>little</word>
    <word>Mary</word>
  </sentence>
  <sentence>
    <word>Cinderella</word>
    <word>likes</word>
    <word>shoes</word>
  </sentence>
</text>";

            // Act
            var result = _target.ConvertToXml(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToCsv_ForEmptyString_ShouldReturnEmptyString()
        {
            // Arrange
            var input = string.Empty;
            var output = string.Empty;

            // Act
            var result = _target.ConvertToCsv(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToCsv_ForWhiteSpacesString_ShouldReturnEmptyString()
        {
            // Arrange
            var input = "   ";
            var output = string.Empty;

            // Act
            var result = _target.ConvertToCsv(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToCsv_ForSingleWord()
        {
            // Arrange
            var input = "Mary";
            var output = @"Word 1
Sentence 1, Mary
";

            // Act
            var result = _target.ConvertToCsv(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToCsv_ForSingleSentence_ShouldReturnCorrectCSV()
        {
            // Arrange
            var input = "Peter called for the wolf, and Aesop came.";
            var output = @"Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8
Sentence 1, Aesop, and, called, came, for, Peter, the, wolf
";

            // Act
            var result = _target.ConvertToCsv(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToCsv_ForMultipleSentences_ShouldReturnCorrectCSV()
        {
            // Arrange
            var input = "Mary had a little lamb. Cinderella likes shoes.";
            var output = @"Word 1, Word 2, Word 3, Word 4, Word 5
Sentence 1, a, had, lamb, little, Mary
Sentence 2, Cinderella, likes, shoes
";

            // Act
            var result = _target.ConvertToCsv(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }

        [Test]
        public void ConvertToCsv_ForMultipleSentencesAndWhiteSpaces_ShouldReturnCorrectCSV()
        {
            // Arrange
            var input = @"   Mary had ,  a 
little 


lamb. 
   Cinderella    likes shoes.   ";
            var output = @"Word 1, Word 2, Word 3, Word 4, Word 5
Sentence 1, a, had, lamb, little, Mary
Sentence 2, Cinderella, likes, shoes
";

            // Act
            var result = _target.ConvertToCsv(input);

            // Assert
            Assert.AreEqual(output, result.Value);
        }
    }
}
