Indicator-UNITY
*** MENU
1. A demo scene in ¡®Indicator/_Scenes/_main¡¯
2. ¡®Arrow Indicator¡¯ and ¡®Box Indicator¡¯ Prefabs in ¡®Indicator/Prefabs/¡¯
3. ¡®PixelPlay.OffScreenIndicator.dll¡¯ in ¡®Indicator/Scripts/Core/¡¯
4. Off screen indicator scripts in ¡®Indicator/Scripts/OffScreenIndicator/¡¯
5. A utility script, ¡®ExtendedFlyCam.cs¡¯ in ¡®Indicator/Scripts/¡¯
6. ¡®WhiteArrow¡¯ and ¡®WhiteBox¡¯ sprites in ¡®Indicator/Sprites/¡¯

*** Add new arrow+ box prefabs
1. Arrow and Box Indicator->'Asset'
2. Add a child to 'UI image' component, then adjust size
3. Change the sprites in 'source image' for 'Image'script component
4. New prefab need to attach 'Indicator.cs' from 'Scripts'

*** Setup Target
1. Create a new tag named ¡®Target¡¯ in the ¡®Tags and Layers¡¯ inspector
2. Open the scene in which you want to add the ¡®Off screen target indicator¡¯.
3. Add a new Canvas to the ¡®Hierarchy¡¯ - ¡®Render Mode¡¯
4. Right click on the above canvas and add a panel as a child to it. (You can rename the
panel if you want to ¡®Off screen indicator panel¡¯).
5. Set the alpha of the above panel to zero
6. Add the ¡®OffScreenIndicator.cs¡¯ script to the above panel.
7. In the same way add ¡®ArrowObjectPool.cs¡¯ and ¡®BoxObjectPool.cs¡¯ scripts to the panel.
And assign the values of the ¡®Pooled Object¡¯ properties for both the scripts with the ¡®Arrow Indicator¡¯ and ¡®Box Indicator¡¯ prefabs respectively from the
¡®Pixel Play/Prefabs/¡¯ folder
8. Now ¡®Target.cs¡¯ script from the scripts folder to all the target game
objects in the scene and adjust the various values of the script properties as you see fit.
9. Testing: add the provided ¡®ExtendedFlyCam.cs¡¯ script to ¡®Main camera¡¯
and hit ¡®Play¡¯.
