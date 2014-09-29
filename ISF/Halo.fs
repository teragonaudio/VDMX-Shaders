/*
{
  "CREDIT": "by Sergey & Nik",
  "DESCRIPTION": "Moves each pixel a randomized distance from its origin",
  "CATEGORIES": [
    "Distortion Effect"
  ],
  "INPUTS": [
    {
      "NAME": "inputImage",
      "TYPE": "image"
    },
    {
      "NAME": "intensityX",
      "LABEL": "Intensity X",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.0
    },
    {
      "NAME": "intensityY",
      "LABEL": "Intensity Y",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 0.0
    },
    {
      "NAME": "randomizeX",
      "LABEL": "Distort X",
      "TYPE": "bool",
      "DEFAULT": 0.0
    },
    {
      "NAME": "randomizeY",
      "LABEL": "Distort Y",
      "TYPE": "bool",
      "DEFAULT": 1.0
    }
  ]
}
*/

float rand(vec2 co) {
  return fract(sin(dot(co.xy, vec2(12.9898, 78.233))) * 43758.5453);
}

void main(void) {
  float maxOffset = 0.1;
  vec2 uv = gl_FragCoord.xy / RENDERSIZE.xy;
  float xPos = randomizeY ? uv.x : 0.0;
  float yPos = randomizeX ? uv.y : 0.0;
  vec2 seed = vec2(TIME, yPos + xPos);
  float randResult = rand(seed);
  float direction = randResult > 0.5 ? -1.0 : 1.0;

  uv.x += maxOffset * randResult * intensityX * direction;
  uv.y += maxOffset * randResult * intensityY * direction;

  gl_FragColor = IMG_NORM_PIXEL(inputImage, uv);
}
