#pragma once
#include "FlexsimDefs.h"
#include "allobjects.h"
#include "EmitterSpec.h"   // EmitShape / DirectionMode / RenderStyle enum values

// Small node-backed SimpleDataType wrappers so FlexScript can read AND write components
// with a persistent memory address, e.g. emitter.startColor.r = 0.5 / emitter.gravity.y = 5.
// (Plain Vec3/Color value properties only allow component READ -- see ObjectDataType's
// reference-returning location/size getters, which the public property binding can't mirror.)
// Each instance lives in a tree node (dt="7" with an sdt::attributetree naming the class);
// its members are bound to child nodes via bindDouble, so writes persist.

namespace Particles {

// Exposed to FlexScript as "Particles.Color". Backing node children: r,g,b,a.
class ColorProperty : public SimpleDataType {
public:
    double r = 1, g = 1, b = 1, a = 1;

    virtual const char* getClassFactory() override { return "Particles::ColorProperty"; }
    virtual void bind() override {
        SimpleDataType::bind();
        bindDouble(r, 1); bindDouble(g, 1); bindDouble(b, 1); bindDouble(a, 1);
    }

    double pget_r() { return r; } void pset_r(double v) { r = v; }
    double pget_g() { return g; } void pset_g(double v) { g = v; }
    double pget_b() { return b; } void pset_b(double v) { b = v; }
    double pget_a() { return a; } void pset_a(double v) { a = v; }

    // Interop with FlexSim's Color value type so `emitter.startColor = Color.red` works.
    operator Color() const { return Color(r, g, b, a); }
    ColorProperty& operator = (const Color& c) { r = c.r; g = c.g; b = c.b; a = c.a; return *this; }
    ColorProperty& operator = (const ColorProperty& o) { r = o.r; g = o.g; b = o.b; a = o.a; return *this; }

    static void bindInterface() {
        bindTypedProperty(r, double, &ColorProperty::pget_r, &ColorProperty::pset_r);
        bindTypedProperty(g, double, &ColorProperty::pget_g, &ColorProperty::pset_g);
        bindTypedProperty(b, double, &ColorProperty::pget_b, &ColorProperty::pset_b);
        bindTypedProperty(a, double, &ColorProperty::pget_a, &ColorProperty::pset_a);
        // FlexScript '=' from a Color (emitter.startColor = Color.red), plus a cast to Color
        // so a Particles.Color converts implicitly (emitter.startColor = emitter.endColor).
        ColorProperty& (ColorProperty::*asgnColor)(const Color&) = &ColorProperty::operator=;
        SimpleDataType::bindOperatorByName<decltype(asgnColor)>("=", asgnColor, "void assign(Color rhs)");
        bindCastOperator(Color, &ColorProperty::operator Color);
    }
};

// Exposed to FlexScript as "Particles.Vec3". Backing node children: x,y,z.
class Vec3Property : public SimpleDataType {
public:
    double x = 0, y = 0, z = 0;

    virtual const char* getClassFactory() override { return "Particles::Vec3Property"; }
    virtual void bind() override {
        SimpleDataType::bind();
        bindDouble(x, 1); bindDouble(y, 1); bindDouble(z, 1);
    }

    double pget_x() { return x; } void pset_x(double v) { x = v; }
    double pget_y() { return y; } void pset_y(double v) { y = v; }
    double pget_z() { return z; } void pset_z(double v) { z = v; }

    // Interop with FlexSim's Vec3 value type so `emitter.gravity = Vec3(...)` works.
    operator Vec3() const { return Vec3(x, y, z); }
    Vec3Property& operator = (const Vec3& v) { x = v.x; y = v.y; z = v.z; return *this; }
    Vec3Property& operator = (const Vec3Property& o) { x = o.x; y = o.y; z = o.z; return *this; }

    static void bindInterface() {
        bindTypedProperty(x, double, &Vec3Property::pget_x, &Vec3Property::pset_x);
        bindTypedProperty(y, double, &Vec3Property::pget_y, &Vec3Property::pset_y);
        bindTypedProperty(z, double, &Vec3Property::pget_z, &Vec3Property::pset_z);
        // FlexScript '=' from a Vec3 (emitter.gravity = Vec3(0,0,-9.8)), plus a cast to Vec3
        // so a Particles.Vec3 converts implicitly (emitter.gravity = emitter.wind).
        Vec3Property& (Vec3Property::*asgnVec)(const Vec3&) = &Vec3Property::operator=;
        SimpleDataType::bindOperatorByName<decltype(asgnVec)>("=", asgnVec, "void assign(Vec3 rhs)");
        bindCastOperator(Vec3, &Vec3Property::operator Vec3);
    }
};

// ---- FlexScript enum namespaces ---------------------------------------------------------
// So scripts read self-documenting names instead of magic numbers, e.g.
//   emitter.shapeField = Particles.Shape.Sphere;   // not  = 5
//   emitter.styleField = Particles.Style.Sprite;   // smoke/textured vs plain points
// Each is a thin class exposing its values as static const int properties; registered with
// bindClassByName in ParticleEmitter::bindInterface. Values mirror the EmitterSpec enums.

class Shape {  // Particles.Shape
public:
    static void bindInterface() {
        SimpleDataType::bindStaticConstIntProperty(Point,  (int)EmitShape::Point);
        SimpleDataType::bindStaticConstIntProperty(Line,   (int)EmitShape::Line);
        SimpleDataType::bindStaticConstIntProperty(Disk,   (int)EmitShape::Disk);
        SimpleDataType::bindStaticConstIntProperty(Plane,  (int)EmitShape::Plane);
        SimpleDataType::bindStaticConstIntProperty(Box,    (int)EmitShape::Box);
        SimpleDataType::bindStaticConstIntProperty(Sphere, (int)EmitShape::Sphere);
    }
};

class Direction {  // Particles.Direction
public:
    static void bindInterface() {
        SimpleDataType::bindStaticConstIntProperty(Aimed, (int)DirectionMode::Aimed);
        SimpleDataType::bindStaticConstIntProperty(Omni,  (int)DirectionMode::Omni);
    }
};

class Style {  // Particles.Style
public:
    static void bindInterface() {
        SimpleDataType::bindStaticConstIntProperty(Points, (int)RenderStyle::Points);
        SimpleDataType::bindStaticConstIntProperty(Sprite, (int)RenderStyle::Sprite);
    }
};

}  // namespace Particles
