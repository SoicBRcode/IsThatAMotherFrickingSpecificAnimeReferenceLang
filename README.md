# IsThatAMotherFrickingSpecificAnimeReferenceLang
An esoteric programming language which is a reference to a specific japanese animation.


# How the language works
  In this language, you can only store numbers in an accumulator. It is an unsigned 
8 bit integer (only can handle numbers from 0 to 255). If you increment it when it
is already 255, it will go back to 0 (the opposite also happens: 0 - 1 = 255).

  A very important thing to know is that the program will loop forever if not explicitely
told to not do so by the "YES" command.

# Commands
    "YES YES YES" - Increments accumulator.
    "YES YES" - Pauses program execution and asks for input as an ascii number.
    "YES" - Terminates program.
    "NO NO NO" - Decrements accumulator.
    "NO NO" - Prints accumulator as an ASCII character.
    "NO" - Jumps to last instruction where the value of the accumulator was 0.
