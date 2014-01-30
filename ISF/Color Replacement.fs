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
      "NAME": "noise",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.0
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

float rand(vec2 co) {
  return fract(sin(dot(co.xy, vec2(12.9898,78.233))) * 43758.5453);
}

void main(void) {
  vec4 inPixel = IMG_THIS_PIXEL(inputImage);
  vec4 outPixel = inPixel;
  
  if(inPixel.r >= (targetColor.r - tolerance) &&
     inPixel.r <= (targetColor.r + tolerance)) {
    if(inPixel.g >= (targetColor.g - tolerance) &&
       inPixel.g <= (targetColor.g + tolerance)) {
      if(inPixel.b >= (targetColor.b - tolerance) &&
         inPixel.b <= (targetColor.b + tolerance)) {
        float noiseAmountR = 0.0;
        float noiseAmountG = 0.0;
        float noiseAmountB = 0.0;
        if(noise > 0.0) {
          noiseAmountR = noise * rand(vec2(TIME, gl_FragColor.r));
          noiseAmountG = noise * rand(vec2(TIME, gl_FragColor.g));
          noiseAmountB = noise * rand(vec2(TIME, gl_FragColor.b));
        }
        outPixel.r = replacementColor.r + noiseAmountR;
        outPixel.g = replacementColor.g + noiseAmountG;
        outPixel.b = replacementColor.b + noiseAmountB;
      }
    }
  }
  
  gl_FragColor = outPixel;
}
