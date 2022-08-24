namespace DuckGame;

public enum TokenId
{
    SingleLineComment,
    MultiLineComment,
    Range,
    Number,
    String,
    RepeatLoop,
    ForLoop,
    In,
    WhileLoop,
    IfStatement,
    ElseStatement,
    Break,
    DefineFunction,
    DefineVariable,
    Instantiate,
    Acquire,
    CompoundingAdd,
    CompoundingSubtract,
    CompoundingDivide,
    CompoundingMultiply,
    Decrement,
    Increment,
    Add,
    Subtract,
    Divide,
    Multiply,
    LogicalAnd,
    LogicalOr,
    GreaterThanOrEqualTo,
    LessThanOrEqualTo,
    GreaterThan,
    LessThan,
    EqualTo,
    NotEqualTo,
    AssignValue,
    ReferenceStaticInstance,
    ReferenceInstance,
    OpenCodeBlock,
    CloseCodeBlock,
    OpenFunctionArguments,
    CloseFunctionArguments,
    OpenCollectionIndexing,
    CloseCollectionIndexing,
    AccessInstanceMembers,
    SeparateParameters,
    SeparateCommands,
    Unknown,
    Space,
    NewLine,
    BooleanTrue,
    BooleanFalse,
    NegateBoolean
}