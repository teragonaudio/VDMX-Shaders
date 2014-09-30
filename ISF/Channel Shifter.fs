/*
{
  "CREDIT": "by Nik Reiman",
  "DESCRIPTION": "Swap RGB values to different channels",
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
      "LABEL": "Wet dry mix",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.5
    },
    {
      "NAME": "swapType",
      "VALUES": [
        0,
        1,
        2,
        3,
        4
      ],
      "LABELS": [
        "RBG",
        "GRB",
        "GBR",
        "BRG",
        "BGR"
      ],
      "DEFAULT": 0,
      "TYPE": "long"
    }
  ]
}
*/

void main(void) {
  vec4 inPixel = IMG_THIS_PIXEL(inputImage);
  vec4 outPixel = inPixel;
  float dryAmount = 1.0 - wetAmount;

  if (swapType == 0) {       // RBG
    outPixel.r = inPixel.r;
    outPixel.g = (inPixel.b * wetAmount) + (inPixel.g * dryAmount);
    outPixel.b = (inPixel.g * wetAmount) + (inPixel.b * dryAmount);
  } else if (swapType == 1) { // GRB
    outPixel.r = (inPixel.g * wetAmount) + (inPixel.r * dryAmount);
    outPixel.g = (inPixel.r * wetAmount) + (inPixel.g * dryAmount);
    outPixel.b = inPixel.b;
  } else if (swapType == 2) { // GBR
    outPixel.r = (inPixel.g * wetAmount) + (inPixel.r * dryAmount);
    outPixel.g = (inPixel.b * wetAmount) + (inPixel.g * dryAmount);
    outPixel.b = (inPixel.r * wetAmount) + (inPixel.b * dryAmount);
  } else if (swapType == 3) { // BRG
    outPixel.r = (inPixel.b * wetAmount) + (inPixel.r * dryAmount);
    outPixel.g = (inPixel.r * wetAmount) + (inPixel.g * dryAmount);
    outPixel.b = (inPixel.g * wetAmount) + (inPixel.b * dryAmount);
  } else if (swapType == 4) { // BGR
    outPixel.r = (inPixel.b * wetAmount) + (inPixel.r * dryAmount);
    outPixel.g = inPixel.g;
    outPixel.b = (inPixel.r * wetAmount) + (inPixel.b * dryAmount);
  } else {
    // Failsafe copy
    outPixel = inPixel;
  }

  gl_FragColor = outPixel;
}