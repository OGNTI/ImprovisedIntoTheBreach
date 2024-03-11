global using Raylib_cs;
global using System.Numerics;
using ImprovisedIntoTheBreach;

//Into the Breach with raylib
//8x8 grid

int screenWidth = 1400;
int screenHeight = 950;
int colsNRows = 8;
int slotSize = 100;


Grid grid = new(new Vector2(screenWidth / 2, screenHeight / 2), colsNRows, colsNRows, slotSize);

Raylib.InitWindow(screenWidth, screenHeight, "hmm");
Raylib.SetTargetFPS(60);


while (!Raylib.WindowShouldClose())
{
    float deltaTime = Raylib.GetFrameTime();
    Vector2 mousePosition = Raylib.GetMousePosition();



    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);

    grid.Draw();

    Raylib.EndDrawing();
}