GliderSharp
=================
A two-dimensional cellular automaton runner written in C# with GtkSharp
user interface.

Includes GUI with the ability to display the simulation in a Gtk.Image widget.
Also features a visual designer for creating the seed of the simulation.

For now it can run only Conway's Game of Life with Moore's neighbourhood
rules. 

It's part of a project I made for school. And I plan on extending it for the
following semesters. There are still a lot of sharp (no pun intended) edges.

The project is free to use, copy and modify in exchange for linking to this
repo.

TODO
=================
* Document the code;
* Serialize and desiarizalize the configuration and the seed from/to XML files;
* Show more UI statistics, like ticks from begining, population;
* Make the game host use only interfaces, so that more rule sets, graphical
engine and possible cell states can be added in the future.

