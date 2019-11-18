using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lesson4Abstracting.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void TestIfTwoCharSequenceReturnsTrue1()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.True(ab.Match("abcd").Success());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsCorrectString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsTrue2()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("ax").Success());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsCorrectString2()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.Equal("ax", ab.Match("ax").RemainingText());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsFalseFromNonMatchedString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("def").Success());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsCorrectStringFromNonMatchedParam()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.Equal("def", ab.Match("def").RemainingText());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsFalseFromEmptyString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("").Success());
        }

        [Fact]
        public void TestIfTwoCharSequenceReturnsFalseFromNullString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match(null).Success());
        }

        [Fact]
        public void TestIfASequenceAndACharReturnsTrue()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            Assert.True(abc.Match("abcd").Success());
        }

        [Fact]
        public void TestIfASequenceAndACharReturnsRightString()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }


        [Fact]
        public void TestIfASequenceAndACharReturnsRightStringForEmptyParam()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            Assert.Equal("", abc.Match("").RemainingText());
        }

        [Fact]
        public void TestIfASequenceAndACharReturnsRightFalseForEmptyParam()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            Assert.False(abc.Match("").Success());
        }

        [Fact]
        public void TestIfASequenceAndACharReturnsRightFalseForNullParam()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            Assert.False(abc.Match(null).Success());
        }

        [Fact]
        public void TestIfASequenceAndACharReturnsRightStringForNullParam()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            var abc = new Sequence(ab, new Character('c'));
            Assert.Equal("", abc.Match("").RemainingText());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqReturnsRightString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.Equal("", hexSeq.Match("u1234").RemainingText());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqNumbersReturnsTrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.True(hexSeq.Match("u1234").Success());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqLettersReturnsRightString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.Equal("ef", hexSeq.Match("uabcdef").RemainingText());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqLettersReturnsTrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.True(hexSeq.Match("uabcdef").Success());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqLettersAndSpacesReturnsRightString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.Equal(" ab", hexSeq.Match("uB005 ab").RemainingText());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqLettersAndSpacesReturnsTrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.True(hexSeq.Match("uB005 ab").Success());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqLetterReturnsRightString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.Equal("abc", hexSeq.Match("abc").RemainingText());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqLetterAndSpacesReturnsTrue()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.False(hexSeq.Match("abc").Success());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqNullReturnsFalse()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.False(hexSeq.Match(null).Success());
        }

        [Fact]
        public void TestIfASequenceWithHexSeqNullReturnsRightString()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Assert.Null(hexSeq.Match(null).RemainingText());
        }
    }
}
