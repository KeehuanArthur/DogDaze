using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetBuilder : SceneBuilder
{
    public override void serealize() {
        frame = new List<List<GameObject>>();


        for (int i=0; i<columns; i++) {
            frame.Add(new List<GameObject>());
            for (int j=0; j<rows; j++ ) {

                if (i > 75 && i < 125) {
                    frame[i].Add(floor_tiles);
                }

                else if (i < 75 && j > 50 && j < 100) {
                    frame[i].Add(floor_tiles);
                }

                else if (i > 250 && j > 200 && j < 250) {
                    frame[i].Add(floor_tiles);
                }

                else {
                    frame[i].Add(null);
                }
            }
        }
    }

}
