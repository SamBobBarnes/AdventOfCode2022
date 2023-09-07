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
    
    [Theory, CombinatorialData]
    public void Monkey_GetEquality_ReturnsExpectedValueMonkey1([CombinatorialValues('+','-','*','/')]char operation)
    {
        var monkey1 = new Monkey2(null,"Monkey1");
        var monkey2 = new Monkey2(2,"Monkey2");
        var monkey3 = new Monkey2("monkey1","monkey2",operation,"monkey3"){OperandMonkey1 = monkey1, OperandMonkey2 = monkey2};
        
        var actual = monkey3.GetExpected(10);

        switch (operation)
        {
            case '+':
                actual.Should().Be(8);
                break;
            case '-':
                actual.Should().Be(12);
                break;
            case '*':
                actual.Should().Be(5);
                break;
            case '/':
                actual.Should().Be(20);
                break;
        }
    }
    
    [Theory, CombinatorialData]
    public void Monkey_GetEquality_ReturnsExpectedValueMonkey2([CombinatorialValues('+','-','*','/')]char operation)
    {
        var monkey1 = new Monkey2(10,"Monkey1");
        var monkey2 = new Monkey2(null,"Monkey2");
        var monkey3 = new Monkey2("monkey1","monkey2",operation,"monkey3"){OperandMonkey1 = monkey1, OperandMonkey2 = monkey2};
        
        var actual = monkey3.GetExpected(5);

        switch (operation)
        {
            case '+':
                actual.Should().Be(-5);
                break;
            case '-':
                actual.Should().Be(5);
                break;
            case '*':
                actual.Should().Be(0);
                break;
            case '/':
                actual.Should().Be(2);
                break;
        }
    }

    [Fact]
    public void Monkey_GetEquality_ReturnsTwoLevelsDeep()
    {
        var monkey1 = new Monkey2(10,"Monkey1");
        var monkey2 = new Monkey2(null,"Monkey2");
        var monkey3 = new Monkey2("monkey1","monkey2",'*',"monkey3"){OperandMonkey1 = monkey1, OperandMonkey2 = monkey2};
        
        var monkey4 = new Monkey2(5,"Monkey4");
        var monkey5 = new Monkey2(2,"Monkey5");
        var monkey6 = new Monkey2("monkey4","monkey5",'-',"monkey6"){OperandMonkey1 = monkey4, OperandMonkey2 = monkey5};
        
        var monkey7 = new Monkey2("monkey3","monkey6",'*',"monkey7"){OperandMonkey1 = monkey3, OperandMonkey2 = monkey6};
        
        var actual = monkey7.GetExpected(60);

        actual.Should().Be(2);
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