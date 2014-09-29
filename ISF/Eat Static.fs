/*
{
  "CREDIT": "by Nik Reiman",
  "DESCRIPTION": "Replace a color with static noise",
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
      "NAME": "targetColor",
      "LABEL": "Target Color",
      "TYPE": "color",
      "DEFAULT": [
        0.0,
        0.0,
        0.0,
        1.0
      ]
    },
    {
      "NAME": "colorStatic",
      "LABEL": "Generate color static",
      "TYPE": "bool",
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
  vec2 inPixelCoord = gl_FragCoord.xy / RENDERSIZE.xy;
  vec4 outPixel = inPixel;

  if(inPixel.r >= (targetColor.r - tolerance) &&
     inPixel.r <= (targetColor.r + tolerance)) {
    if(inPixel.g >= (targetColor.g - tolerance) &&
       inPixel.g <= (targetColor.g + tolerance)) {
      if(inPixel.b >= (targetColor.b - tolerance) &&
         inPixel.b <= (targetColor.b + tolerance)) {
        if(colorStatic) {
          outPixel.r = rand(vec2(TIME, outPixel.r + outPixel.g + outPixel.b));
          outPixel.g = rand(vec2(TIME, outPixel.r + outPixel.g + outPixel.b));
          outPixel.b = rand(vec2(TIME, outPixel.r + outPixel.g + outPixel.b));
        } else {
          vec2 seed = vec2(TIME, outPixel.r + outPixel.g + outPixel.b + inPixelCoord.x * inPixelCoord.y);
          float outValue = rand(seed);
          outPixel.r = outValue;
          outPixel.g = outValue;
          outPixel.b = outValue;
        }
      }
    }
  }

  gl_FragColor = outPixel;
}