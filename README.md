# Sharpener Calculator

## Introduction
There are many sharpening machines available, but all of them are somehow difficult to adjust to generate a perfect blade using a defined angle.  
The following picture shows such a machine and makes it easy understanding the difficulty in adjusting it:  

![Tormek T-8](https://github.com/cmbTea/SharpenerCalculator/blob/master/machine.png?raw=true)

The model you see here is a <a href="https://www.tormek.com/uk/en/machine-models/tormek-t-4-original/" target="blank">**Tormek T-8**</a>. On the website you will see also a lot of videos on how to use it.  

In general you attach your knife to a jig and place it on a so called *Universal Support Bar (USB)*. The height of the top of the USB relative to the axis of the wheel and its horizontal distance to the axis define the grinding angle. To adjust the height of the USB to get a desired sharpening angle you typically use the *AngleMaster* shown in the picture below:  

![AngleMaster](https://github.com/cmbTea/SharpenerCalculator/blob/master/angleMaster.png?raw=true)

It provides good results, but misses a kind of repeatability. Thanks to the SharpenerCalculator you can overcome this problem and archive a perfect blade in a repeatable quality. This is a schematic of the machine and it shows you some important machine specific measurements you need to calculate the grinding angle.  

![Machine sketch up](https://github.com/cmbTea/SharpenerCalculator/blob/master/src/sketch.PNG?raw=true)

The USB can be used on top of the machine or beside the machine. Both positions are supported by the SharpenerCalculator. As already said above the horizontal and vertical distance of the top of the USB to the axis of the wheel are important and machine specific. SharpenerCalculator provides these settings for the Tormek T-4 and T-8 model in both positions. Beside that you can define custom settings. This allows you to easily add configurations for other machines or for specific jigs or jig extenders. Configurations can be stored and loaded so that you can share configurations with others. We will be happy if you share your configurations with us.  

## Using the SharpenerCalculator

Using the SharpenerCalculator is pretty much straight forward. In a first step you select your machine type from the combobox. This will show the machine parameters but if you want to change them you can use the *Custom* machine parameters which will allow you to edit the values. Using the small **+** button you can add this configuration to the combobox, or you use the small **-** button to remove the current configuration.  
After selecting the machine type you need to define the diameter of your wheel. The Tormek T-8 uses 250mm wheels, the T-4 200mm wheels.  
Next step is to measure the *jig projection length*. That is the distance from the jig to the blade.  
Finally you need to define your target angle and the calculator will show you the distance from the top of the USB to the housing of the machine as well as the distance from the top od the USB to the wheel.  

![SharpenerCalculator screenshot01](https://github.com/cmbTea/SharpenerCalculator/blob/master/screenshot01.PNG?raw=true)

Using the *File* menu you can load and save machine lists or restore the default machine list:  

![SharpenerCalculator screenshot02](https://github.com/cmbTea/SharpenerCalculator/blob/master/screenshot02.PNG?raw=true)

Switch on your machine and enjoy your sharp knifes.
