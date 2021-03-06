﻿#version 150
#extension GL_ARB_separate_shader_objects : require

layout(location = 0) in vec3 vertexPosition;
layout(location = 1) in vec2 vertexTextureCoord;
layout(location = 2) in vec4 vertexColor;
layout(location = 3) in vec3 vertexNormal;

out vec4 fragmentColor;
out vec2 fragmentTextureCoord;

out vec4 diffuse, ambient;
out vec3 normal, halfVector;

uniform int passNumber;

void main(void)
{
	normal = normalize(gl_NormalMatrix * vertexNormal);
	halfVector = gl_LightSource[0].halfVector.xyz;

	diffuse = gl_FrontMaterial.diffuse * gl_LightSource[0].diffuse;
	ambient = gl_FrontMaterial.ambient * gl_LightSource[0].ambient;
	ambient += gl_LightModel.ambient * gl_FrontMaterial.ambient;

	gl_Position = gl_ModelViewProjectionMatrix * vec4(vertexPosition, 1.0);

	fragmentColor = vertexColor;
	fragmentTextureCoord = vertexTextureCoord;
}
