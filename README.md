- [Description](#objectretracter)

- [Why use this?](#why-use-this)

- [showcase](#showcase)

# ObjectRetracter

ObjectRetracter is a script for Object/Weapon colission detection currently using a 3d mesh made up of 6 adjacent cubes that represent areas of colission,
so far the object defaults to area 2, depending on which areas are triggered/active the object/weapon will move/lerp to a non-active/free area. 

![image](https://user-images.githubusercontent.com/61057195/165966533-3c80cceb-db21-41ef-b600-ba6b0436f6b2.png)


![2022-04-28_11-57](https://user-images.githubusercontent.com/61057195/165789778-a324b6ed-c16d-49d6-af48-4573a84d4077.png)

## Why use this?

this is mainly an attempt to create a somewhat realistic feature for my game but it might help others with this problem, i find this approach to be far more convenient than using 2 cameras or high intensive CPU usage physics in order to prevent a weapon/object from clipping through walls or other obstacles.

### showcase

![123456](https://user-images.githubusercontent.com/61057195/165959520-08d3ccae-64c7-40b0-a435-ac305697519b.png)

All areas are untoggled/inactive

![2](https://user-images.githubusercontent.com/61057195/165959555-2d01e7b7-6a2a-4450-ac61-56f2298983b2.png)

area 2 is toggled, object lerps to 1-6

![123](https://user-images.githubusercontent.com/61057195/165959591-d445c256-d12e-4e0c-bc05-fcfd9cc36b54.png)

area 1,2 and 3 are toggled, object lerps to 6

![12](https://user-images.githubusercontent.com/61057195/165959609-3bb390c0-39eb-4e6c-b89a-5e7b03034953.png)

area 1 and 2 are toggled, object lerps to 3-6, if area 6 is ever obstructed the object will hide 

https://user-images.githubusercontent.com/61057195/165780541-73892456-6dd2-4d76-8c6a-bb8968170288.mp4
