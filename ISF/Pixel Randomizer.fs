/*{
	"CREDIT": "by Sergey & Nik",
	"CATEGORIES": [
		"Distortion Effect"
	],
	"INPUTS": [
		{
			"NAME": "inputImage",
			"TYPE": "image"
		},
    {
      "NAME": "intensity",
      "TYPE": "float",
      "MIN": 0.0,
      "MAX": 1.0,
      "DEFAULT": 1.0
    },
    {
      "NAME": "distortX",
      "TYPE": "bool",
      "DEFAULT": 0.0
    },
    {
      "NAME": "distortY",
      "TYPE": "bool",
      "DEFAULT": 1.0
    }
	]
}*/

float rand(vec2 co) {
    return fract(sin(dot(co.xy, vec2(12.9898,78.233))) * 43758.5453);
}

void main(void)
{
    float maxOffset = 0.1;
    vec2 uv = gl_FragCoord.xy / RENDERSIZE.xy;
    float xPos = distortX ? uv.x : 0.0;
    float yPos = distortY ? uv.y : 0.0;

    uv.y += maxOffset * rand(vec2(TIME, yPos + xPos) * intensity);
    uv.x += maxOffset * rand(vec2(TIME, yPos + xPos) * intensity);
    gl_FragColor = IMG_NORM_PIXEL(inputImage, uv);
}
