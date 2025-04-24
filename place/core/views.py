from django.shortcuts import render
from .models import Event, Category
from django.core.paginator import Paginator
from django.db.models import Q


# Create your views here.
def index(request):
    categories = Category.objects.filter()

    return render(
        request,
        "core/index.html",
        {
            "categories": categories,
        },
    )


def htmx_events(request):
    # clean if no filtering
    # Note that the query is prioritized
    if (
        not request.GET
        or "query" in request.GET
        or "event_filters" not in request.session
    ):
        request.session["event_filters"] = {}
    else:
        pass

    # set or restore filters
    query = request.GET.get(
        "query", request.session["event_filters"].get("query", None)
    )
    category = request.GET.get(
        "category", request.session["event_filters"].get("category", None)
    )
    location_type = request.GET.get(
        "location_type", request.session["event_filters"].get("location_type", None)
    )
    period = request.GET.get(
        "period", request.session["event_filters"].get("period", None)
    )
    free = request.GET.get("free", request.session["event_filters"].get("free", None))
    page = request.GET.get("page", request.session["event_filters"].get("page", None))

    # save filters
    request.session["event_filters"] = {
        "query": query,
        "category": category,
        "location_type": location_type,
        "period": period,
        "free": free,
        "page": page,
    }

    # period or query filter
    if query:
        events = Event.objects.filter(
            Q(title__icontains=query)
            | Q(description__icontains=query)
            | Q(location__icontains=query)
        )
    elif period == "today":
        events = Event.today()
    elif period == "next_weeks":
        events = Event.next_weeks()
    else:
        events = Event.this_week()

    # location filter
    onsite = [Event.LocationType.ONSITE, Event.LocationType.HYBRID]
    remote = [Event.LocationType.REMOTE, Event.LocationType.HYBRID]

    if location_type in onsite:
        events = events.filter(location_type__in=onsite)
    elif location_type in remote:
        events = events.filter(location_type__in=remote)
    else:
        pass

    # price filter
    if free == "on":
        events = events.filter(price_amount=0)
    else:
        pass

    # category filter
    if category:
        events = events.filter(category=category)
    else:
        pass

    # pagination
    page_events = Paginator(events, 6).get_page(page)

    return render(request, "core/events.html", {"page_events": page_events})
