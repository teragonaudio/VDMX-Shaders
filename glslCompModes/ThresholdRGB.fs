/*

	Discussion:

	//	Fill in this function to composite the top layer over the bottom layer
	vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
	
	//	Fill in this function for conditions when top layer is invisible  / ignored (opacity = 0)
	vec4 CompositeBottom(vec4 bottom, float bottomAlpha)

	//	Fill in this function for conditions when bottom layer is invisible / ignored (opacity = 0)	
	vec4 CompositeTop(vec4 top, float topAlpha)
	
	//	Incoming variables
	vec4 bottom - bottom pixel color (RGBA)
	vec4 top - top pixel color (RGBA)
	float bottomAlpha - opacity of bottom layer
	float topAlpha - opacity of top layer

*/

vec4 CompositeBottomAndTop(vec4 bottom, float bottomAlpha, vec4 top, float topAlpha)
{		

	
	float		brightTop =  top.a * (top.r + top.g + top.b) / 3.0;
	vec4		darkenedBottom = vec4(bottomAlpha) * bottom;
	
	vec4		returnMe;
	
	//	Use topAlpha is our threshold- anything brighter than it should appears as the bottom image
	//	Do this on a per-color channel basis to get a funky effect
	returnMe.r = (top.r <= topAlpha) ? (top.r) : (bottom.r * bottomAlpha);
	returnMe.g = (top.g <= topAlpha) ? (top.g) : (bottom.g * bottomAlpha);
	returnMe.b = (top.b <= topAlpha) ? (top.b) : (bottom.b * bottomAlpha);
	returnMe.a = (top.a <= topAlpha) ? (top.a) : (bottom.a * bottomAlpha);
	
	returnMe = mix(darkenedBottom, returnMe, top.a);
	returnMe.a = top.a;
	return returnMe;
}

vec4 CompositeBottom(vec4 bottom, float bottomAlpha)	{
	vec4		returnMe = vec4(bottomAlpha)*bottom;
	return returnMe;
}

vec4 CompositeTop(vec4 top, float topAlpha)	{
	vec4		returnMe = vec4(topAlpha)*top;
	return returnMe;
}
