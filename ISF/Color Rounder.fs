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
      "NAME": "wetAmount",
      "LABEL": "Wet-dry mix",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.0
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
  vec4 tempPixel = inPixel;
  float dryAmount = 1.0 - wetAmount;

  if (inPixel.r >= tolerance) {
    tempPixel.r = invert ? 0.0 : 1.0;
  } else {
    tempPixel.r = invert ? 1.0 : 0.0;
  }

  if (inPixel.g >= tolerance) {
    tempPixel.g = invert ? 0.0 : 1.0;
  } else {
    tempPixel.g = invert ? 1.0 : 0.0;
  }

  if (inPixel.b >= tolerance) {
    tempPixel.b = invert ? 0.0 : 1.0;
  } else {
    tempPixel.b = invert ? 1.0 : 0.0;
  }

  vec4 outPixel;
  outPixel.r = (inPixel.r * dryAmount) + (tempPixel.r * wetAmount);
  outPixel.g = (inPixel.g * dryAmount) + (tempPixel.g * wetAmount);
  outPixel.b = (inPixel.b * dryAmount) + (tempPixel.b * wetAmount);

  gl_FragColor = outPixel;
}
