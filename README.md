# PowerPoint MIDI Presenter Add-on
A simple PowerPoint Add-On to change slides based on MIDI CC events

The primary goal of this add-on is to allow a musician or engineer control a set using standard footpedal controllers.

PowerPoint has only 2 levels of hiearchy:
  - Section
  - Slide

Therefore each slide is given a tag with a key that represents its hierachy at 3 levels:
  - Song, analagous to Section
  - Part Tag or Part such as Verse, Chorus, Bridge or other user defined tag
  - Sort Order, representing the order within a Part
  - In addition, each slide tag configuration also supports a MIDI CC number

A valid presentation consists of:
- Sections representing a single song
- Slides representing any part within a song or PPT Section
- Slides sharing a matching part tag can contain more than one slide and can have the same MIDI command.  A MIDI event for a part will iterate over any slide by slide or sort order, cycling back to the begining if no more slides within a part is found

This is in an early prototype stage with MIDI polling and slide tagging but no event assignments.  Currently an Arturia MiniLab is being used as a test controller for this application

The following has to be done to leave prototype:
- [ ] A presentation manager to 
  - Keep each slide's SlideConfiguration tag in sync with its parent Song/Section
  - Track conflicting CC assignments within the same song but different parts
- [ ] Ribbon Bar Global Presentation Settings for 
  - MIDI channel and device assignment
  - Section and Slide navigation
- [ ] Task Pane for active slide MIDI settings 
- [ ] Song Part UI Tag Editor
- [ ] Ribbon Bar Global setting to toggle the add-in events on or off so that new presentations are not automatically interrogated or modified
