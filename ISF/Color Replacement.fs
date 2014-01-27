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
  
  if(inPixel.x >= (targetColor.x - tolerance) &&
     inPixel.x <= (targetColor.x + tolerance)) {
    if(inPixel.y >= (targetColor.y - tolerance) &&
       inPixel.y <= (targetColor.y + tolerance)) {
      if(inPixel.z >= (targetColor.z - tolerance) &&
         inPixel.z <= (targetColor.z + tolerance)) {
        outPixel.x = replacementColor.x;
        outPixel.y = replacementColor.y;
        outPixel.z = replacementColor.z;
      }
    }
  }
  
  gl_FragColor = outPixel;
}
