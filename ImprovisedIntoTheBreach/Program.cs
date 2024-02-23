global using Raylib_cs;

//Into the Breach with raylib
//8x8 grid

Raylib.InitWindow(800, 600, "hmm");
Raylib.SetTargetFPS(60);










while (!Raylib.WindowShouldClose())
{


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);

    Raylib.DrawGrid(100, 1f);

    Raylib.EndDrawing();
}