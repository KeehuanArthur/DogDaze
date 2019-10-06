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

                if (i > 10 && i < 20) {
                    frame[i].Add(floor_tiles);
                }

                else if (i <= 10 && j > 20 && j < 30) {
                    frame[i].Add(floor_tiles);
                }

                else if (i >= 20 && j > 40 && j < 50) {
                    frame[i].Add(floor_tiles);
                }

                else if ( j > 60 ) {
                    frame[i].Add(floor_tiles);
                }

                else {
                    frame[i].Add(null);
                }
            }
        }
    }

}
