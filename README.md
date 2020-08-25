ArborAddonRewired is an addon to use Rewired on Arbor 3.

# Install

* Import Rewired into your project.
* Install Rewired Control Mapper.
* Import Arbor into your project.
* Download unitypackage from [Latest release](https://github.com/caitsithware/ArborAddonRewired/releases/latest)
* Import ArborAddonRewired_x.y.z.unitypackage into your project

# Main flow

1. Preparation of Rewired

* From the Create button of Hierarchy, select "Create Other / Rewired / Input Manager" to create a RewiredInputManager.
* Click the "Launch Rewired Editor" button of the Inspector of RewiredInputManager to open the RewiredEditor window.
* Set up Players, Actions, various Maps.

2. Use with ArborFSM

* From the Create button of Hierarchy, select "Arbor / ArborFSM" to create a ArborFSM.
* Click the "Open Editor" button of the Inspector of ArborFSM to open the ArborEditor window.
* Right click on the graph view and select "Create State".
* Click the gear icon in the header section of the state and select "Add Behaviour".
* Select "Rewired / Transition / RewiredButtonDownTransition".
* Set the following fields
    * Player Name : Player name registered in RewiredInputManager
    * Action Name : Action name registered in RewiredInputManager
    * Axis Contribution : Type of axial direction to be determined. In the case of Any, transitions if there is input irrespective of sign.
* Drag and drop the "On Button Down" field to another place and select "Create State".

3. Play check

* Click the play button.
* Press the button with the set Player name and Action name.
* Check the transition in ArborFSM.

# Examples

Example scene is in the following folder in the project.  
Assets/caitsithware/ArborAddons/AddonRewired/Examples/

# Support version

| Tools   | Version    |
|---------|------------|
| Unity   | 2017.4.40f1 |
| Arbor   | 3.7.0      |
| Rewired | 1.1.36.0   |

# Asset Store

## Arbor 3

https://www.assetstore.unity3d.com/#!/content/112239?aid=1101lGsc

## Rewired

https://www.assetstore.unity3d.com/#!/content/21676?aid=1101lGsc

# License

zlib license

# Copyright

* Arbor 3 : Copyright (c) 2014-2020 Cait Sith Ware. All rights reserved.
* Rewired : Copyright (c) 2018 Augie R. Maddox, Guavaman Enterprises. All rights reserved.
