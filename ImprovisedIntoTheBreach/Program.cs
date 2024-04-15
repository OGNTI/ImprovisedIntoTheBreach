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
List<Bug> bugs = new();
List<Unit> units = new();
List<Button> buttons = new();
List<IClickable> clickables = new();
List<IDrawable> drawables = new();
List<GameObject> gameObjects = new();

Grid grid = new(new Vector2(screenWidth / 2, screenHeight / 2), colsNRows, colsNRows, slotSize);

Raylib.InitWindow(screenWidth, screenHeight, "hmm");
Raylib.SetTargetFPS(60);

mechs.Add(new Mech(grid, grid.Slots[4, 4]));
bugs.Add(new Bug(grid, grid.Slots[3, 2]));

buttons.Add(new Button(new(grid.GetRightSide() + 15, 750, Raylib.MeasureText("End Turn", 36) + 15, 50), "End Turn", () => grid.turn++));

units.AddRange(mechs);
units.AddRange(bugs);
clickables.AddRange(units);
clickables.AddRange(buttons);
drawables.Add(grid);
drawables.AddRange(units);
drawables.AddRange(buttons);
gameObjects.Add(grid);
gameObjects.AddRange(units);

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

