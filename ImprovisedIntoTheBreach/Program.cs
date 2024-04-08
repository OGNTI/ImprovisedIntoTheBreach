global using Raylib_cs;
global using System.Numerics;
using ImprovisedIntoTheBreach;

//Into the Breach with raylib
//8x8 grid

int screenWidth = 1400;
int screenHeight = 950;
int colsNRows = 8;
int slotSize = 100;

List<Mech> mechs = new();
List<IClickable> clickables = new();
List<IDrawable> drawables = new();
List<GameObject> gameObjects = new();


Grid grid = new(new Vector2(screenWidth / 2, screenHeight / 2), colsNRows, colsNRows, slotSize);

Raylib.InitWindow(screenWidth, screenHeight, "hmm");
Raylib.SetTargetFPS(60);

mechs.Add(new Mech(grid, grid.Slots[4, 4]));

clickables.AddRange(mechs);

drawables.Add(grid);
drawables.AddRange(mechs);

gameObjects.Add(grid);
gameObjects.AddRange(mechs);

while (!Raylib.WindowShouldClose())
{
    float deltaTime = Raylib.GetFrameTime();
    Vector2 mousePosition = Raylib.GetMousePosition();



    if (Raylib.IsMouseButtonPressed(0))
    {
        foreach (IClickable c in clickables)
        {
            if (c.IsHovering(mousePosition))
            {
                c.Click();
            }
        }
    }

    gameObjects.ForEach(g => g.Update(deltaTime)); 

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.White);

    drawables.ForEach(d => d.Draw()); 

    Raylib.EndDrawing();
}

