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
        0.12,
        0.58,
        0.91,
        1.0
      ]
    },
    {
      "NAME": "intensity",
      "TYPE": "long",
      "MIN": 0,
      "MAX": 100,
      "DEFAULT": 100
    },
    {
      "NAME": "tolerance",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.0
    }
  ],
  "PASSES": [
    {
      "TARGET": "pass1"
    },
    {
      "TARGET": "pass2"
    }
  ]
}
*/

varying vec2 offsets[1];

void main(void) {
  vec4 inPixel = IMG_THIS_PIXEL(inputImage);

  if(PASSINDEX == 0) {
    if(inPixel.x >= (targetColor.x - tolerance) &&
       inPixel.x <= (targetColor.x + tolerance)) {
      if(inPixel.y >= (targetColor.y - tolerance) &&
         inPixel.y <= (targetColor.y + tolerance)) {
        if(inPixel.z >= (targetColor.z - tolerance) &&
           inPixel.z <= (targetColor.z + tolerance)) {
          vec2 tmpPixelCoord;
          tmpPixelCoord.x = 0.0;
          tmpPixelCoord.y = 0.0;
          vec4 tmpPixel;
          vec4 outPixel;
          for(int i = 0; i < intensity; i++) {
            tmpPixelCoord.y++;
            tmpPixel = IMG_NORM_PIXEL(inputImage, tmpPixelCoord);
            outPixel = IMG_NORM_PIXEL(pass1, tmpPixelCoord);
            outPixel = inPixel.rgba + tmpPixel.rgba;
          }
        }
      }
    }
  }
  else if(PASSINDEX == 1) {
    gl_FragColor = IMG_NORM_PIXEL(pass1, offsets[0]);
    
  }

}
