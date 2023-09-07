using AdventOfCode2022.Day21;

namespace UnitTests.Day21;

public class Tribe2Tests
{
    #region Monkey
    
    [Fact]
    public void Monkey_Create_WithValue()
    {
        var expected = new Monkey2
        {
            Value = 1
        };
        
        var actual = new Monkey2(1);
        
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory, CombinatorialData]
    public void Monkey_Create_WithOperation([CombinatorialValues('+','-','*','/','=')]char operation)
    {
        var expected = new Monkey2
        {
            Operand1 = "1",
            Operand2 = "2",
            Type = operation switch {
                '+' => 1,
                '-' => 2,
                '*' => 3,
                '/' => 4,
                '=' => 5,
                _ => 0
            }
        };
        
        var actual = new Monkey2("1","2",operation);
        
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Monkey_GetValue_ReturnsValueOfValueMonkey()
    {
        var actual = new Monkey2(1,"Monkey1");

        actual.GetValue().Should().Be(1);
    }

    [Theory, CombinatorialData]
    public void Monkey_GetValue_ReturnsValueOfOperationMonkey([CombinatorialValues('+','-','*','/')]char operation)
    {
        var operand = new Monkey2(3,"Monkey1");
        
        var actual = new Monkey2("Monkey1","Monkey1",operation,"Monkey2");

        actual.OperandMonkey1 = operand;
        actual.OperandMonkey2 = operand;

        switch (operation)
        {
            case '+':
                actual.GetValue().Should().Be(6);
                break;
            case '-':
                actual.GetValue().Should().Be(0);
                break;
            case '*':
                actual.GetValue().Should().Be(9);
                break;
            case '/':
                actual.GetValue().Should().Be(1);
                break;
        }
    }
    
    [Fact]
    public void Monkey_GetEquality_ReturnsExpectedValueOfMonkey1()
    {
        var monkey1 = new Monkey2(null,"Monkey1");
        var monkey2 = new Monkey2(2,"Monkey2");
        var monkey3 = new Monkey2("monkey1","monkey2",'+',"monkey3"){OperandMonkey1 = monkey1, OperandMonkey2 = monkey2};
        
        var actual = monkey3.GetExpected(8);
        
        actual.Should().Be(6);
    }
    
    [Fact]
    public void Monkey_GetEquality_ReturnsExpectedValueOfMonkey2()
    {
        var monkey1 = new Monkey2(5,"Monkey1");
        var monkey2 = new Monkey2(null,"Monkey2");
        var monkey3 = new Monkey2("monkey1","monkey2",'+',"monkey3"){OperandMonkey1 = monkey1, OperandMonkey2 = monkey2};
        
        var actual = monkey3.GetExpected(8);
        
        actual.Should().Be(3);
    }
    
    #endregion
    
    #region Tribe

    [Fact]
    public void Tribe_Create()
    {
        var monkey1 = new Monkey2
        {
            Name = "monkey1",
            Type = 0,
            Value = 5,
            Operand1 = "",
            OperandMonkey1 = null,
            OperandMonkey2 = null,
            Operand2 = ""
        };
        var monkey2 = new Monkey2
        {
            Name = "humn",
            Type = 0,
            Value = null,
            Operand1 = "",
            OperandMonkey1 = null,
            OperandMonkey2 = null,
            Operand2 = ""
        };
        var monkey3 = new Monkey2
        {
            Name = "root",
            Type = 5,
            Value = null,
            Operand1 = "monkey1",
            OperandMonkey1 = monkey1,
            OperandMonkey2 = monkey2,
            Operand2 = "humn"
        };
        
        var expected = new List<Monkey2>
        {
            monkey1,
            monkey2,
            monkey3
        };

        var input = new List<string>
        {
            "monkey1: 5",
            "humn: 7",
            "root: monkey1 + humn"
        };
        
        var actual = new Tribe2(input);
        
        actual.Monkeys.Should().BeEquivalentTo(expected);
        actual.Root.Should().BeEquivalentTo(monkey3);
    }
    
    #endregion
}