/*
{
  "CREDIT": "by Nik Reiman",
  "DESCRIPTION": "Round pixel RGB values up or down",
  "CATEGORIES": [
    "Color Effect"
  ],
  "INPUTS": [
    {
      "NAME": "inputImage",
      "TYPE": "image"
    },
    {
      "NAME": "tolerance",
      "LABEL": "Color detection tolerance",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.5
    },
    {
      "NAME": "invert",
      "LABEL": "Invert output pixel values",
      "TYPE": "bool",
      "DEFAULT": 0.0
    }
  ]
}
*/

void main(void) {
  vec4 inPixel = IMG_THIS_PIXEL(inputImage);
  vec4 outPixel = inPixel;

  if(inPixel.r >= tolerance) {
    outPixel.r = invert ? 0.0 : 1.0;
  } else {
    outPixel.r = invert ? 1.0 : 0.0;
  }

  if(inPixel.g >= tolerance) {
    outPixel.g = invert ? 0.0 : 1.0;
  } else {
    outPixel.g = invert ? 1.0 : 0.0;
  }

  if(inPixel.b >= tolerance) {
    outPixel.b = invert ? 0.0 : 1.0;
  } else {
    outPixel.b = invert ? 1.0 : 0.0;
  }

  gl_FragColor = outPixel;
}