/*
{
  "CREDIT": "by Nik Reiman",
  "DESCRIPTION": "Replaces a color with a strobe light effect",
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
      "DEFAULT": 0.0
    },
    {
      "NAME": "targetColor",
      "LABEL": "Target Color",
      "TYPE": "color",
      "DEFAULT": [
        0.0,
        0.0,
        0.0,
        1.0
      ]
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
        outPixel.r = rand(vec2(TIME, 1.0));
        outPixel.g = rand(vec2(TIME, 1.0));
        outPixel.b = rand(vec2(TIME, 1.0));
      }
    }
  }

  gl_FragColor = outPixel;
}