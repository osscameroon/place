from django.db import models
from django.template.defaultfilters import slugify
from django.utils import timezone


# Create your models here.
class Category(models.Model):
    name = models.CharField(max_length=255, unique=True)
    description = models.CharField(max_length=255, default="", blank=True)
    icon = models.CharField(max_length=32, default="question-square")

    class Meta:
        verbose_name_plural = "categories"
        ordering = ("name",)

    def __str__(self):
        return self.name


class Event(models.Model):
    class LocationType(models.TextChoices):
        ONSITE = "onsite", "On Site"
        REMOTE = "remote", "Remote"
        HYBRID = "hybrid", "Hybrid"

    title = models.CharField(max_length=255)
    slug = models.SlugField(null=False, unique=True)
    description = models.CharField(max_length=1024, default="", blank=True)
    datetime = models.DateTimeField()
    location_type = models.TextField(choices=LocationType, default=LocationType.ONSITE)
    location = models.CharField(max_length=255)
    category = models.ForeignKey(Category, on_delete=models.CASCADE)
    image = models.ImageField(blank=True, null=True)
    # TODO: check https://github.com/django-money/django-money
    price_amount = models.FloatField(default=0.0)
    price_currency = models.CharField(default="XAF")
    status = models.BooleanField(default=False)
    created_date = models.DateTimeField(auto_now=True)

    class Meta:
        ordering = ("-datetime",)

    def __str__(self):
        return self.title

    def get_absolute_url(self):
        return reverse("event_detail", kwargs={"slug": self.slug})

    @classmethod
    def today(cls):
        events = cls.objects.filter(datetime__date=timezone.now().date(), status=True)

        return events

    @classmethod
    def this_week(cls):
        now = timezone.now().date()

        start_week = now - timezone.timedelta(days=now.weekday() - 1)
        end_week = start_week + timezone.timedelta(days=7)
        events = cls.objects.filter(
            datetime__date__gte=start_week, datetime__date__lt=end_week
        )

        return events

    @classmethod
    def next_weeks(cls):
        now = timezone.now().date()

        next_week = now + timezone.timedelta(days=7 - now.weekday())
        events = cls.objects.filter(datetime__date__gte=next_week)

        return events
