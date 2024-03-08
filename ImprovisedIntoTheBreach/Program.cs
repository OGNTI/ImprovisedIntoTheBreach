global using Raylib_cs;
global using System.Numerics;
using ImprovisedIntoTheBreach;

//Into the Breach with raylib
//8x8 grid

int screenWidth = 1400;
int screenHeight = 950;
int gridSize = 8;
int cellSize = 100;

Grid grid = new(new Vector2(screenWidth / 2, screenHeight / 2), gridSize, gridSize, cellSize);



Raylib.InitWindow(screenWidth, screenHeight, "hmm");
Raylib.SetTargetFPS(60);





while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);

    grid.Draw();

    Raylib.EndDrawing();
}