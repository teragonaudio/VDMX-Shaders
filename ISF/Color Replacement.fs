/*
{
  "CREDIT": "by Nik Reiman",
  "CATEGORIES": [
    "Color Effect"
  ],
  "INPUTS": [
    {
      "NAME": "inputImage",
      "TYPE": "image"
    },
    {
      "NAME": "targetColor",
      "TYPE": "color",
      "DEFAULT": [
        0.0,
        0.0,
        0.0,
        1.0
      ]
    },
    {
      "NAME": "replacementColor",
      "TYPE": "color",
      "DEFAULT": [
        0.0,
        0.0,
        0.0,
        1.0
      ]
    },
    {
      "NAME": "tolerance",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.0
    }
  ]
}
*/

void main(void) {
  vec4 inPixel = IMG_THIS_PIXEL(inputImage);
  vec4 outPixel = inPixel;
  float halfTolerance = tolerance / 2.0;
  
  if(inPixel.x > (targetColor.x - halfTolerance) &&
     inPixel.x < (targetColor.x + halfTolerance)) {
    if(inPixel.y > (targetColor.y - halfTolerance) &&
       inPixel.y < (targetColor.y + halfTolerance)) {
      if(inPixel.z > (targetColor.z - halfTolerance) &&
         inPixel.z < (targetColor.z + halfTolerance)) {
        outPixel.x = replacementColor.x;
        outPixel.y = replacementColor.y;
        outPixel.z = replacementColor.z;
      }
    }
  }
  
  gl_FragColor = outPixel;
}
